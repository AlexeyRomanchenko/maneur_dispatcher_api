using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Models.Rails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Point = AGAT.LocoDispatcher.Business.Models.RailsModels.Point;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class PointManager
    {
        private PointRepository _repository;
        public PointManager()
        {
            _repository = new PointRepository();
        }
        public IEnumerable<Point> GetPointsByParkId(int parkId)
        {
            try
            {
                IEnumerable<Data.Models.Rails.Point> _points = _repository.GetById(parkId);
                IEnumerable<Point> points = Mapper.GetMapperInstance().Map<IEnumerable<Point>>(_points);
                return points;
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }

        public void CreatePoints(int parkId, Point point)
        {
            try
            {
                Data.Models.Rails.Point _point = Mapper.GetMapperInstance().Map<Data.Models.Rails.Point>(point);
                _point.ParkId = parkId;
                _repository.Create(_point);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Point> GetPointByCode(string checkpoint, int parkId)
        {
            try
            {
                Data.Models.Rails.Point _point  = await _repository.GetByCode(checkpoint, parkId);
                Point point = Mapper.GetMapperInstance().Map<Point>(_point);
                return point;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
