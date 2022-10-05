using Core.DataAccess;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = Entites.Concrete.Color;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {

    }
}
