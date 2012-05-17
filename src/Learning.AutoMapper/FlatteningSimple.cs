using NUnit.Framework;
using SharpTestsEx;

using AutoMapper;

namespace Learning.AutoMapper
{
    [TestFixture]
    public class FlatteningSimple
    {
        [Test]
        public void HierarchyToFlattenObject()
        {
            Mapper.CreateMap<Person, PersonFlat>();
            Mapper.AssertConfigurationIsValid();

            var source = new Person
            {
                Name = "Elemar Junior",
                Address = new Address
                {
                    Street = "St. Francis",
                    Number = 1024
                }
            };

            var destination = Mapper.Map<Person, PersonFlat>(source);

            destination.Name.Should().Be(source.Name);
            destination.AddressStreet.Should().Be(source.Address.Street);
            destination.AddressNumber.Should().Be(source.Address.Number);
            destination.Salary.Should().Be(source.GetSalary());
        }


        class Address
        {
            public string Street { get; set; }
            public int Number { get; set; }
        }

        class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; }
            public decimal GetSalary()
            {
                return 25;
            }
        }

        class PersonFlat
        {
            public string Name { get; set; }
            public string AddressStreet { get; set; }
            public int AddressNumber { get; set; }
            public decimal Salary { get; set; }
        }
    }
}
