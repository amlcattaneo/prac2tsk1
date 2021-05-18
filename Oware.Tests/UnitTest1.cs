using NUnit.Framework;

namespace Oware.Tests
{
    public class MockSH:IScoreHouse {
        public int GetCount() {
            throw new SystemNotImplementedException();
        }
        public string AddSeed(Seed seed){
            return "YES"
        }
        public void Reset() {
            throw new SystemNotImplementedException();
        }
    } 
    public class Tests
    {


        [Test]
        public void WhenResetHouseActuallyResets()
        {
            //ARRANGE 
            House h = new House(0,0);
            //ACT
            for (int i =0;i<5;i++){
            h.AddSeedInPot( new Seed());
            }           //   <------ adding seeds to h in order to change its state from initial
            h.ResetHouse();       // <------ this is the method we are testing 
            //ASSERT
            Assert.AreEqual(4,h.GetCount(),"Resetting a house puts it back to its original state"); 
            // ^ the x-pos and y-pos values don't need to be checked as they weren't altered
        }
        [Test]
        public void WhenAddSeedMethodIsCalled(){
            //ARRANGE 
            MockSH m = new MockSH();
            player p = new player("Test", m);
            Seed s = new Seed();
            //ACT
            string teststring = p.AddSeed(s);
            //ASSERT
            Assert.AreEqual(teststring, "YES","AddSeed method is actually called");

            
        }
    }
}