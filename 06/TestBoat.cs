// namespace _06;

// public class TestBoat
// {
//     [Fact]
//     public void TestParse()
//     {
//         var lines = File.ReadAllLines("input/test_input.txt");
//         var races = Program.ParseRaces(lines);
//         Assert.Equal((15,40), races[1]);
//         Assert.Equal(3, races.Count());
//     }

//     [Fact]
//     public void TestChargeTimes()
//     {
//         var program = new Program();
//         var times = program.GetChargeTimes((7, 9));
//         Assert.Equal(2, times.low);
//         Assert.Equal(5, times.high);
//     }
// }