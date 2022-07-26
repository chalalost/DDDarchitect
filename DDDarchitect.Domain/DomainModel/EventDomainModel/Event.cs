using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using DDDarchitect.Domain.DomainModel.EventDomainModel.Events;
using Microservice.Framework.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Domain.DomainModel.EventDomainModel
{
    public class Event : AggregateRoot<Event, EventId>
    {
        #region cto
        public Event() : this(null)
        {

        }
        public Event(EventId id) : base(id)
        {

        }
        #endregion
        #region property
        public string EventName { get; set; }
        public decimal Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CategoryId CategoryId { get; set; }
        #endregion
        #region methods
        public void AddEvent(
            string eventName,
            int price,
            string artist,
            DateTime date,
            string description,
            string imageUrl,
            CategoryId categoryId)
        {
            EventName = eventName;
            Price = price;
            Artist = artist;
            Date = date;
            Description = description;
            ImageUrl = imageUrl;
            CategoryId = categoryId;

            Emit(new AddedEvent(
                eventName,
                price,
                artist,
                date,
                description,
                imageUrl,
                categoryId
                ));
        }
        #endregion
    }
}
