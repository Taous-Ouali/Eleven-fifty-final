using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventPlanner.Data.Context;
using EventPlanner.Data.Entities;
using EventPlanner.Models.TableModels;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Services.TableServices
{
    public class TableService : ITableService
    {
        private IMapper _mapper;
        public ApplicationDbContext _context;

            public TableService(IMapper mapper, ApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }
        public async Task<bool> CreateTable(TableCreate model)
        {
            var table = _mapper.Map<Table>(model);
            await _context.Tables.AddAsync(table);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table is null) return false;
            else 
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<TableDetail> GetTableById(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table is null) return new TableDetail();

            return _mapper.Map<TableDetail>(table);
        }

        public async Task<List<TableListItem>> GetTables()
        {
            var conversion = await _context.Tables.ToListAsync();
            return _mapper.Map<List<TableListItem>>(conversion);
        }

        public async Task<bool> UpdateTable(TableEdit model)
        {
            var table = await _context.Tables.FindAsync(model.Id);
            if (table is null) return false;
            else
            {
                table.Id = model.Id;
                table.AmountOfChairs = model.AmountOfChairs;
                table.Price = model.Price;

                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}