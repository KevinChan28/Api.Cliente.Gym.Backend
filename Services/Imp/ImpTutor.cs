using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpTutor : ITutor
    {
        private IIdentificationImageRepository _identificationImageRepository;
        private ISocialMediaRepository _socialMediaRepository;
        private IAddressRepository _addressRepository;
        private ITutorRepository _tutorRepository;

        public ImpTutor(IIdentificationImageRepository identificationImageRepository, ISocialMediaRepository socialMediaRepository, IAddressRepository addressRepository,
                ITutorRepository tutorRepository)
        {
            _identificationImageRepository = identificationImageRepository;
            _socialMediaRepository = socialMediaRepository;
            _addressRepository = addressRepository;
            _tutorRepository = tutorRepository;
        }
        public async Task<int> TutorRegister(TutorRegister tutorData)
        {
            Address address = new Address
            {
                Nationality = tutorData.Address.Nationality,
                Municipaly = tutorData.Address.Municipaly,
                Locality = tutorData.Address.Locality,
                ZipCode = tutorData.Address.ZipCode,
                Street = tutorData.Address.Street,
                Neighborhood = tutorData.Address.Neighborhood,
                InteriorNumber = tutorData.Address.InteriorNumber,
                OutdoorNumber = tutorData.Address.OutdoorNumber
            };
            int addressId = await _addressRepository.RegisterAddress(address);

            int socialMediaId = 0;
            if (tutorData.SocialMedia != null)
            {
                SocialMedia socialMedia = new SocialMedia
                {
                    Facebook = tutorData.SocialMedia.Facebook,
                    Instagram = tutorData.SocialMedia.Instagram,
                    Twitter = tutorData.SocialMedia.Twitter
                };
                socialMediaId = await _socialMediaRepository.RegisterSocialMedia(socialMedia);
            }

            Tutor tutor = new Tutor
            {
                KinshipId = tutorData.KinshipId,
                SocialMediaId = socialMediaId,
                AddressId = addressId,
                Name = tutorData.Name,
                LastName = tutorData.LastName,
                Email = tutorData.Email,
                Birthdate = tutorData.Birthdate,
                Phone = tutorData.Phone
            };

            int tutorId = await _tutorRepository.AddTutor(tutor);

            return tutorId;
        }
    }
}
