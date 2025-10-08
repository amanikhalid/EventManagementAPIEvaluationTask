using AutoMapper;
using EventManagementAPIEvaluationTask.DTOs;
using EventManagementAPIEvaluationTask.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagementAPIEvaluationTask.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<CreateEventDto, Event>();
            CreateMap<Attendee, AttendeeDto>();
            CreateMap<RegisterAttendeeDto, Attendee>();

        }
    }
}
