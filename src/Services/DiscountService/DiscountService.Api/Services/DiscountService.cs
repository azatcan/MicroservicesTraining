using CategoryService.Shared.Dtos;
using Dapper;
using DiscountService.Api.Models;
using Npgsql;
using System.Data;

namespace DiscountService.Api.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id",new { Id=id });
            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found", 404);
        }

        public async Task<Response<List<Discount>>> GetAll()
        {
            var discounts = (await _dbConnection.QueryAsync<Discount>("SELECT * FROM discount"));
            return Response<List<Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select * from discount where userid = @UserId and code=@Code", new {Code=code, UserId = userId });
            var hasDisconut = discounts.FirstOrDefault();

            if (hasDisconut == null)
            {
                return Response<Models.Discount>.Fail("discount not found", 404);
            }
            return Response<Models.Discount>.Success(hasDisconut, 200);

        }

        public async Task<Response<Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where id=@Id", new { Id =id })).SingleOrDefault();

            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Disconut not found", 404);
            }
            return Response<Models.Discount>.Success(discount, 200);

        }

        public async Task<Response<NoContent>> Save(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("INSERT INTO discount (userid,rate,code) VALUES (@UserId,@Rate,@Code)", discount);
            if (status > 0) 
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("an error occured while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId,code=@Code,rate=@Rate where id=@Id",new
            {
                Id= discount.Id,
                UserId = discount.UserId,
                Code = discount.Code,
                Rate=discount.Rate,
            });

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("discont not found",404);
        }
    }
}
