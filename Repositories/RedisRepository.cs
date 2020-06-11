using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace RouletteApi.Repositories
{
    public class RedisRepository {
        private readonly IRedisCacheClient _redisCacheClient;
        public RedisRepository(IRedisCacheClient redisCacheClient)
        {
            _redisCacheClient = redisCacheClient;
        }
        public async Task<List<RouletteModel>> Read(string id){
            // RouletteModel roulettes = new List<RouletteModel>();
            List<RouletteModel> roulettes = await _redisCacheClient.Db0.GetAsync<List<RouletteModel>>(id);
            
            return roulettes;
        }
        public async Task<bool> Add(string id, List<RouletteModel> roulettes){
            bool isAdd = await _redisCacheClient.Db0.AddAsync(id,roulettes);

            return isAdd;
        }
    }
}