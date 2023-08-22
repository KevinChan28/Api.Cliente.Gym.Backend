using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;
using Org.BouncyCastle.Crypto;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpSuscriptions : ISuscription
    {
        private ISuscriptionRepository _suscriptionRepository;

        public ImpSuscriptions(ISuscriptionRepository suscriptionRepository)
        {
            _suscriptionRepository = suscriptionRepository;
        }

        public async Task<SuscriptionExpire> GetSuscriptionToExpire(DateTime dateExpire, int numberPage, int numberRecords, Boolean isAsc)
        {
            List<SuscriptionToExpireData> suscriptionToExpireData = await _suscriptionRepository.GetSuscriptionToExpire(dateExpire, numberPage, numberRecords, isAsc);
            SuscriptionExpire suscriptionExpire = new SuscriptionExpire();
            suscriptionExpire.TotalCount = suscriptionToExpireData.FirstOrDefault().TotalCount;
            suscriptionExpire.HasNextPage = suscriptionToExpireData.FirstOrDefault().HasNextPage;
            suscriptionExpire.HasPreviusPage = suscriptionToExpireData.FirstOrDefault().HasPreviusPage;
            suscriptionExpire.Items = suscriptionToExpireData.Select(p => new SuscriptionToExpireItem
            {
                SuscriptionId = p.SuscriptionId,
                CustomerId = p.CustomerId,
                FullName = p.FullName,
                Email = p.Email,
                Description = p.Description,
                EndDate =  p.EndDate.ToString("dd/MM/yyyy"),
                PathImage = p.PathImage,
                MimeType = p.MimeType
            }).ToList();
            return suscriptionExpire;
        }
        public async Task<SuscriptionExpire> GetSuscriptionToUser(string nameUser, int numberPage, int numberRecords, bool isAsc)
        {
            List<SuscriptionToExpireData> suscriptionToExpiretoNameUser = await _suscriptionRepository.GetSuscriptionToNameUser(nameUser, numberPage, numberRecords, isAsc);
            SuscriptionExpire suscriptionExpire = new SuscriptionExpire();
            suscriptionExpire.TotalCount = suscriptionToExpiretoNameUser.FirstOrDefault().TotalCount;
            suscriptionExpire.HasNextPage = suscriptionToExpiretoNameUser.FirstOrDefault().HasNextPage;
            suscriptionExpire.HasPreviusPage = suscriptionToExpiretoNameUser.FirstOrDefault().HasPreviusPage;
            suscriptionExpire.Items = suscriptionToExpiretoNameUser.Select(p => new SuscriptionToExpireItem
            {
                SuscriptionId = p.SuscriptionId,
                IsDeptor = !p.IsPayUp ?? false,
                CustomerId = p.CustomerId,
                FullName = p.FullName,
                Email = p.Email,
                Description = p.Description,
                EndDate = p.EndDate.ToString("dd/MM/yyyy"),
                PathImage = p.PathImage,
                MimeType = p.MimeType
            }).ToList();
            return suscriptionExpire;
        }
    }
}
