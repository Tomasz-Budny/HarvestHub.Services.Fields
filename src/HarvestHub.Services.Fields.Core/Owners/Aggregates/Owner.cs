using HarvestHub.Services.Fields.Core.Fields.ValueObjects;
using HarvestHub.Services.Fields.Core.Owners.ValueObjects;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Services.Fields.Core.Owners.Aggregates
{
    public class Owner : AggregateRoot<OwnerId>
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Point? StartLocation { get; private set; }
        public Address? Address { get; private set; }
        public uint NumberOfFields { get; private set; } = 0;
        public Area SumArea { get; private set; } = 0;

        public Owner(OwnerId id, FirstName firstName, LastName lastName, Point startLocation, Address address, uint numberOfFields, Area sumArea) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            StartLocation = startLocation;
            Address = address;
            NumberOfFields = numberOfFields;
            SumArea = sumArea;
        }

        public void ChangeStartLocation(Point startLocation, Address address)
        {
            StartLocation = startLocation;
            Address = address;
        }

        public void AddField(Area area)
        {
            SumArea += area;
            NumberOfFields++;
        }

        public void RemoveField(Area area)
        {
            SumArea -= area;
            NumberOfFields--;
        }

        public void ChangeFieldArea(Area oldArea, Area newArea)
        {
            SumArea = SumArea - oldArea + newArea;
        }
    }
}
