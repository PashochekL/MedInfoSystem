using MedInfoSystem.Data;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Services
{
    public class TokenBlacklistService
    {
        private readonly AppDBContext _dbContext;

        public TokenBlacklistService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RevokeTokenAsync(string token)
        {
            _dbContext.RevokedTokens.Add(new RevokedToken
            {
                Token = token,
                RevokedAt = DateTime.UtcNow
            });
            await _dbContext.SaveChangesAsync();
        }

        public bool IsTokenRevoked(string token)
        {
            var revoked = _dbContext.RevokedTokens.Any(rt => rt.Token == token);
            
            return _dbContext.RevokedTokens.Any(rt => rt.Token == token);
        }
    }
}
