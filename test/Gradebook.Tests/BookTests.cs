using GradeBook;

namespace Gradebook.Tests;

public class BookTests
{
    [Fact]
    public void GradeHasApprovedValue()
    {
        var book = new InMemoryBook("");

        try
        {
            book.AddGrade(2);
            book.AddGrade(45.8);
            //book.AddGrade(172);
            //book.AddGrade(-20);

            return;
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Fact]
    public void BookCalculatesStats()
    {
        //arrange
        var book = new InMemoryBook("");
        book.AddGrade(1.23);
        book.AddGrade(99.9);
        book.AddGrade(45.8);

        //act
        var result = book.GetStatistics();

        //assert
        Assert.Equal(49, result.Average, 1);
        Assert.Equal(99.9, result.High);
        Assert.Equal(1.23, result.Low);
        Assert.Equal('F', result.Letter);
    }
}