using ITBoostUp.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.BusinessLayer.IRepository
{
    public interface IStateRepository
    {
        public int Create(State state);
        public int Update(State state);
        public void Delete(int id);

        public List<StateList> List();
        public State GetElementById(int id);
    }
}
