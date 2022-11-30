using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Cart : ICart
{
    DalApi.IDal dal = new Dal.DalList();
}
