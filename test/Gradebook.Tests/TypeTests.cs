using GradeBook;

namespace Gradebook.Tests

{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var  result = log("Hello!");

            Assert.Equal(3, count);
        } 

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void HowStringBehaves()
        {
            string name = "Marg";
            var upper = MakeUpperCase(name);
            
            Assert.Equal("Marg", name);
            Assert.Equal("MARG", upper);
        }

        private string MakeUpperCase(string param)
        {
            return param.ToUpper(); //returns a copy, a new string, not the same
        }

        [Fact]
        public void GetIntValueType()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void NewNameCanBeSetFromRef()
        {
            //arrange
            var book1 = GetBook("Book M");

            //act
            GetBookSetName(ref book1, "NewM");

            //assert
            Assert.Equal("NewM", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void NewNameSettingFromValue()
        {
            //arrange
            var book1 = GetBook("Book M");

            //act
            GetBookSetName(book1, "NewM");

            //assert
            Assert.Equal("Book M", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        
        [Fact]
        public void NewNameSettingFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act
            SetName(book1, "NewName");

            //assert
            Assert.Equal("NewName", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            
            Assert.Equal(book2, book1);

            Assert.Same(book1, book2);

            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}