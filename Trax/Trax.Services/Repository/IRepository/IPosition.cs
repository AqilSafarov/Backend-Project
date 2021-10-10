using System;
using System.Collections.Generic;
using System.Text;
using Trax.Models;

namespace Trax.Services.Repository.IRepository
{
    public interface IPosition
    {
        List<Models.Position> GetPositions();

        Models.Position GetPosition();
        Models.Position CreatePosition(Models.Position model);
        Models.Position UpdatePosition(Models.Position model);
        bool DeletePosition(int id);
        Models.Position GetPosition(int? id);

    }
}
