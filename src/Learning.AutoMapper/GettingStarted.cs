using NUnit.Framework;
using SharpTestsEx;

using AutoMapper;

namespace Learning.AutoMapper
{
    [TestFixture]
    public class GettingStarted
    {

        [Test]
        public void MappingIntPropertyToStringProperty()
        {
            Mapper.CreateMap<Foo, Fee>();
            Mapper.AssertConfigurationIsValid();
            
            var source = new Foo {Data = 3};
            var destination = Mapper.Map<Foo, Fee>(source);

            destination.Data.Should().Be("3");
        }

        [Test]
        public void MappingStringPropertyToIntProperty()
        {
            Mapper.CreateMap<Fee, Foo>();
            Mapper.AssertConfigurationIsValid();

            var source = new Fee { Data = "3" };
            var destination = Mapper.Map<Fee, Foo>(source);

            destination.Data.Should().Be(3);
        }

        [Test]
        public void MappingStringPropertyToIntProperty_SourceIsNull()
        {
            Mapper.CreateMap<Fee, Foo>();
            Mapper.AssertConfigurationIsValid();

            var source = new Fee { Data = null };
            var destination = Mapper.Map<Fee, Foo>(source);

            destination.Data.Should().Be(0);
        }


        class Foo
        {
            public int Data { get; set; }
        }

        class Fee
        {
            public string Data { get; set; }
        }
    }
}
