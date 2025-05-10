using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> GetAll();
        Task<Reserva> GetById(int id);
        Task Add(Reserva reserva);
        Task Update(Reserva reserva);
        Task Delete(int id);
    }
}