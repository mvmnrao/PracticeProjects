using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using ImgToTextLambda;

namespace ImgToTextLambda.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TestTransformToText()
        {
            TestLambdaContext context = new TestLambdaContext();

            ImgToTextTasks functions = new ImgToTextTasks();

            var state = new State
            {
                //Name = "MyStepFunctions"
            };


            //state = functions.TransformToText(state, context);

            //Assert.Equal(5, state.WaitInSeconds);
            //Assert.Equal("Hello MyStepFunctions", state.Message);
        }
    }
}
