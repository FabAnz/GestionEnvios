using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        public void Add(T obj);
        public void Remove(int id);
        public void Update(T obj);
        public List<T> FindAll();
        public T FindById(int id);
    }
}
