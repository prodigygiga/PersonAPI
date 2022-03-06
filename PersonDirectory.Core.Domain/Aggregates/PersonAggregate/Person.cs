using Domain.Core.Shared;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class Person : Entity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PrivateNumber { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }
        public string PicturePath { get; private set; }
        private readonly HashSet<PhoneNumber> phoneNumbers;
        private readonly HashSet<PersonRelation> relations;
        public IReadOnlyCollection<PhoneNumber> PhoneNumbers => phoneNumbers;
        public IReadOnlyCollection<PersonRelation> Relations => relations;
        protected Person()
        {
            phoneNumbers = new HashSet<PhoneNumber>();
            relations = new HashSet<PersonRelation>();
        }

        public Person(string firstName, string lastName, string privateNumber,Gender gender, DateTime birthDate, int cityId,string picturePath):this()
        {
            FirstName = firstName;
            LastName = lastName;
            PrivateNumber = privateNumber;
            Gender = gender;
            BirthDate = birthDate;
            CityId = cityId;
            PicturePath = picturePath;
        }
        public void SetId(int id)
        {
            this.Id = id;
        }
        public void SetPersonInfo(string firstName, string lastName, string privateNumber, Gender gender, DateTime birthDate, int cityId, string picturePath)
        {
            FirstName = firstName;
            LastName = lastName;
            PrivateNumber = privateNumber;
            Gender = gender;
            BirthDate = birthDate;
            CityId = cityId;
            PicturePath = picturePath;
        }
        public void SetPicturePath(string picturePath)
        {
            PicturePath = picturePath;
            ModifiedDate = DateTime.Now;
        }
        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            phoneNumbers.Add(phoneNumber);
        }
        public void AddRelation(PersonRelation relation)
        {
            relations.Add(relation);
        }
    }
}
