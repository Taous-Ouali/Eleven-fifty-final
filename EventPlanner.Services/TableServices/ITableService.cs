using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models.GuestModels;
using EventPlanner.Models.TableModels;

namespace EventPlanner.Services.TableServices
{
    public interface ITableService
    {
        Task<bool> CreateTable(TableCreate model);
        Task<bool> UpdateTable(TableEdit model);
        Task<bool> DeleteTable(int id);
        Task<TableDetail> GetTableById(int id);
        Task<List<TableListItem>> GetTables();
    }
}