namespace Xbehave.Execution
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class ScenarioOutline : XunitTestCase
    {
        public ScenarioOutline(
            IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod)
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, null)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Called by the de-serializer", true)]
        public ScenarioOutline()
        {
        }

        public override async Task<RunSummary> RunAsync(
            IMessageSink diagnosticMessageSink,
            IMessageBus messageBus,
            object[] constructorArguments,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource) =>
                await new ScenarioOutlineRunner(
                        diagnosticMessageSink,
                        this,
                        this.DisplayName,
                        this.SkipReason,
                        constructorArguments,
                        messageBus,
                        aggregator,
                        cancellationTokenSource)
                    .RunAsync();
    }
}
