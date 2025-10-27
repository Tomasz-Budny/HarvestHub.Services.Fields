using HarvestHub.Services.Fields.Core.Fields.Entities;
using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using HarvestHub.Services.Fields.Core.Fields.Primitives;
using HarvestHub.Services.Fields.Core.Fields.ValueObjects;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Services.Fields.Core.Fields.Aggregates
{
    public class Field : AggregateRoot<FieldId>
    {
        public OwnerId OwnerId { get; set; }
        public Name Name { get; set; }
        public Point Center { get; set; }
        public DateTime CreatedAt { get; set; }
        public Area Area { get; set; }
        public FieldClassStatus Class { get; set; }
        public OwnershipStatus OwnershipStatus { get; set; }
        public Address Address { get; set; }
        public HexColor Color { get; set; }

        protected LinkedList<Vertex> _vertices = new();
        public IReadOnlyCollection<Vertex> Vertices => _vertices;

        public Field(FieldId Id, OwnerId ownerId, Name name, Point center, 
            DateTime createdAt, Area area, FieldClassStatus @class, OwnershipStatus ownershipStatus, 
            Address address, HexColor color)
            :base(Id)
        {
            OwnerId = ownerId;
            Name = name;
            Center = center;
            CreatedAt = createdAt;
            Area = area;
            Class = @class;
            OwnershipStatus = ownershipStatus;
            Address = address;
            Color = color;
        }

        public void InsertVertices(LinkedList<Vertex> insertVertices)
        {
            LinkedListNode<Vertex>? currentNode = _vertices.First;
            LinkedListNode<Vertex>? currInsertNode = insertVertices.First;
            uint orderCount = 0;

            while (currentNode != null)
            {
                currentNode.Value.Order = orderCount;
                while (currInsertNode is not null &&
                       currentNode is not null &&
                       currInsertNode.Value.Order == currentNode.Value.Order)
                {
                    _vertices.AddBefore(currentNode, currInsertNode.Value);
                    orderCount++;
                    currInsertNode = currInsertNode.Next;
                    currentNode.Value.Order = orderCount;
                }

                orderCount++;
                currentNode = currentNode?.Next;
            }

            while(currInsertNode != null)
            {
                currInsertNode.Value.Order = orderCount;
                _vertices.AddLast(currInsertNode.Value);

                currInsertNode = currInsertNode.Next;
                orderCount++;
            }
        }

        public Vertex GetVertex(VertexId vertexId)
        {
            var vertex = _vertices.SingleOrDefault(vertex => vertex.Id == vertexId);

            if(vertex == null)
            {
                throw new VertexNotFoundException(vertexId);
            }

            return vertex;
        }

        public void UpdateVertex(Vertex updatedVertex)
        {
            var vertex = GetVertex(updatedVertex.Id);

            if (vertex is null)
            {
                throw new VertexNotFoundException(updatedVertex.Id);
            }

            _vertices.Find(vertex).Value = updatedVertex;
        }

        public void UpdateVertices(IEnumerable<Vertex> updatedVertices)
        {
            foreach (var vertex in updatedVertices)
            {
                UpdateVertex(vertex);
            }
        }

        public void SetVertices(IEnumerable<Vertex> vertices)
        {
            _vertices.Clear();
            uint index = 0;
            foreach (var vertex in vertices)
            {
                vertex.Order = index;
                _vertices.AddLast(vertex);
                index++;
            }
        }
    }
}
