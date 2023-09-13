using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventPlanner.Data.Entities;
using EventPlanner.Models.EventModels;
using EventPlanner.Models.GuestModels;
using EventPlanner.Models.TableModels;

namespace EventPlanner.Services.Configurations
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<Event, EventCreate>().ReverseMap();
            CreateMap<Event, EventDetail>().ReverseMap();
            CreateMap<Event, EventEdit>().ReverseMap();
            CreateMap<Event, EventListItem>().ReverseMap();

            CreateMap<Guest, GuestCreate>().ReverseMap();
            CreateMap<Guest, GuestDetail>().ReverseMap();
            CreateMap<Guest, GuestEdit>().ReverseMap();
            CreateMap<Guest, GuestListItem>().ReverseMap();

            CreateMap<Table, TableCreate>().ReverseMap();
            CreateMap<Table, TableDetail>().ReverseMap();
            CreateMap<Table, TableEdit>().ReverseMap();
            CreateMap<Table, TableListItem>().ReverseMap();
        }
    }
}