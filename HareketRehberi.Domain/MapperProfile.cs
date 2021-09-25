using AutoMapper;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;

namespace HareketRehberi.Domain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SystemUserRequest, SystemUser>();
            CreateMap<QuestionRequest, Question>();
            CreateMap<AnswerRequest, Answer>();
        }
    }
}
