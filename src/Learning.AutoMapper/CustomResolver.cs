using NUnit.Framework;
using SharpTestsEx;

using AutoMapper;

namespace Learning.AutoMapper
{
    [TestFixture]
    public class CustomResolver
    {
        [Test]
        public void SummarizeUsingCustomResolver()
        {
            Mapper.CreateMap<Src, Dst>()
                .ForMember(dst => dst.Total, opt => opt.ResolveUsing<TotalResolver>());

            Mapper.AssertConfigurationIsValid();

            var source = new Src {Value1 = 10, Value2 = 15};
            var dest = Mapper.Map<Src, Dst>(source);

            dest.Total.Should().Be(source.Value1 + source.Value2);
        }

        [Test]
        public void SummarizeUsingMapFrom()
        {
            Mapper.CreateMap<Src, Dst>()
                .ForMember(dst => dst.Total, opt => opt.MapFrom(src => src.Value1 + src.Value2));

            Mapper.AssertConfigurationIsValid();

            var source = new Src { Value1 = 10, Value2 = 15 };
            var dest = Mapper.Map<Src, Dst>(source);

            dest.Total.Should().Be(source.Value1 + source.Value2);
        }

        class TotalResolver : ValueResolver<Src, int>
        {
            protected override int ResolveCore(Src source)
            {
                return source.Value1 + source.Value2;
            }
        }

        class Src
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
        }

        class Dst
        {
            public int Total { get; set; }
        }
    }
}
