using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IDataManager
    {
        string Print();

        bool Save();

        bool Load();

        bool CreateTestData();

        bool Reset();
    }
}
