using System.Collections.Generic;
using Aplication.Client.API.Context;
using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Cursor;
using Org.BouncyCastle.Crypto;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpSuscriptionsRepository : ISuscriptionRepository
    {
        DBContext _context;
        public ImpSuscriptionsRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<List<SuscriptionToExpireData>> GetSuscriptionToExpire(DateTime dateExpire, int numberPage, int numberRecords, bool isAsc)
        {
            return await _context.SuscriptionExpire.FromSqlInterpolated($@"Call GetSuscriptionToExpire ({dateExpire}, {numberPage}, {numberRecords},{isAsc})").ToListAsync();
        }

        public async Task<List<SuscriptionToExpireData>> GetSuscriptionToNameUser(string nameUser, int numberPage, int numberRecords, bool isAsc)
        {
            return await _context.SuscriptionExpire.FromSqlInterpolated($@"Call GetSuscriptionToNameUser ({nameUser},{numberPage}, {numberRecords},{isAsc})").ToListAsync();
        }
    }
}
