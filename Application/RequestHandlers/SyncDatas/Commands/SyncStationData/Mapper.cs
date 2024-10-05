using static Application.RequestHandlers.SyncDatas.Commands.SyncStationData.RequestModel;

namespace Application.RequestHandlers.SyncDatas.Commands.SyncStationData
{
    public class Mapper
    {
        // Yeni tank grup nesnelerini oluşturur
        public List<TankGroup> MapToNewEntity(List<TankGroupRequestModel> tankGroupRequests, Guid stationId)
        {
            return tankGroupRequests.Select(t => new TankGroup
            {
                Id = t.TableUniqueId,
                Name = t.Name,
                TableUniqueId = t.TableUniqueId,
                StationId = stationId
            }).ToList();
        }

        // Mevcut tank gruplarını günceller
        public List<TankGroup> MapToUpdateTankGroups(List<TankGroup> tankGroups, List<TankGroupRequestModel> tankGroupRequests)
        {
            return tankGroups.Select(existing =>
                {
                    var updateData = tankGroupRequests.FirstOrDefault(t => t.TableUniqueId == existing.TableUniqueId);
                    existing.Name = updateData.Name;
                    existing.TableUniqueId = updateData.TableUniqueId;
                    return existing;
                })
                .ToList();
        }

        // Cevap modelini oluşturur
        public ResponseModel MapToResponse(bool isEverythingOk)
        {
            return new ResponseModel
            {
                IsEverythingOk = isEverythingOk
            };
        }
    }
}
