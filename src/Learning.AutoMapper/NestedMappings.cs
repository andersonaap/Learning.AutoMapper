using System;

using NUnit.Framework;
using SharpTestsEx;

using AutoMapper;

namespace Learning.AutoMapper
{
    [TestFixture]
    public class NestedMappings
    {
        [Test]
        public void SrcToDst()
        {
            Mapper.CreateMap<SrcParent, DstParent>();
            Mapper.CreateMap<SrcChild, DstChild>();
            Mapper.AssertConfigurationIsValid();

            var source = new SrcParent()
            {
                Value = 3,
                Child = new SrcChild
                {
                    AnotherValue = 4
                }
            };

            var dest = Mapper.Map<SrcParent, DstParent>(source);
            dest.Value.Should().Be(source.Value);
            dest.Child.AnotherValue.Should().Be(
                source.Child.AnotherValue
                );
        }

        class SrcParent
        {
            public int Value { get; set; }
            public SrcChild Child { get; set; }
        }

        class SrcChild
        {
            public int AnotherValue { get; set; }
        }

        class DstParent
        {
            public int Value { get; set; }
            public DstChild Child { get; set; }
        }

        class DstChild
        {
            public int AnotherValue { get; set; }
        }
        
    }
}
