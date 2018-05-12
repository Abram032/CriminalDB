using System;
using Xunit;

namespace CriminalDBTests.OtherTests
{
    public class GenericParserTests
    {
        [Fact]
        public void IntParseTest()
        {
            Assert.Equal(10, ParseValue<int>(int.TryParse, "10"));
            Assert.Throws<ArgumentException>(() => ParseValue<int>(int.TryParse, "test"));
        }

        [Fact]
        public void DoubleParseTest()
        {
            Assert.Equal(10.234, ParseValue<double>(double.TryParse, "10,234"));
            Assert.Throws<ArgumentException>(() => ParseValue<double>(double.TryParse, "test"));
        }

        [Fact]
        public void FloatParseTest()
        {
            Assert.Equal(10.234f, ParseValue<float>(float.TryParse, "10,234"));
            Assert.Throws<ArgumentException>(() => ParseValue<float>(float.TryParse, "test"));
        }

        [Fact]
        public void LongParseTest()
        {
            Assert.Equal(10, ParseValue<long>(long.TryParse, "10"));
            Assert.Throws<ArgumentException>(() => ParseValue<long>(long.TryParse, "test"));
        }

        [Fact]
        public void ByteParseTest()
        {
            Assert.Equal(10, ParseValue<byte>(byte.TryParse, "10"));
            Assert.Throws<ArgumentException>(() => ParseValue<byte>(byte.TryParse, "test"));
        }

        [Fact]
        public void CharParseTest()
        {
            Assert.Equal('c', ParseValue<char>(char.TryParse, "c"));
            Assert.Throws<ArgumentException>(() => ParseValue<char>(char.TryParse, "test"));
        }

        [Fact]
        public void BoolParseTest()
        {
            Assert.True(ParseValue<bool>(bool.TryParse, "true"));
            Assert.True(ParseValue<bool>(bool.TryParse, "True"));
            Assert.False(ParseValue<bool>(bool.TryParse, "false"));
            Assert.False(ParseValue<bool>(bool.TryParse, "False"));
            Assert.Throws<ArgumentException>(() => ParseValue<bool>(bool.TryParse, "test"));
        }

        private T ParseValue<T>(TryParseHandler<T> handler, string value) where T : struct
        {
                if(handler(value, out T result))
                    return result;
                else
                    throw new ArgumentException();
        }

        public delegate bool TryParseHandler<T>(string value, out T result);
    }
}