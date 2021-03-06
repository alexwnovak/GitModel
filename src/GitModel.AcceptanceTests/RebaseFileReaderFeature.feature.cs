﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GitModel.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RebaseFileReaderFeatureFeature : Xunit.IClassFixture<RebaseFileReaderFeatureFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "RebaseFileReaderFeature.feature"
#line hidden
        
        public RebaseFileReaderFeatureFeature(RebaseFileReaderFeatureFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RebaseFileReaderFeature", "\tAs an interactive rebase editor writer\r\n\tI want to read Git rebase files\r\n\tSo I " +
                    "can allow the user to configure how their rebase behaves", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Reading rebase file")]
        [Xunit.TraitAttribute("FeatureTitle", "RebaseFileReaderFeature")]
        [Xunit.TraitAttribute("Description", "Reading rebase file")]
        [Xunit.TraitAttribute("Category", "Acceptance")]
        public virtual void ReadingRebaseFile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading rebase file", new string[] {
                        "Acceptance"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action",
                        "CommitHash",
                        "Subject"});
            table1.AddRow(new string[] {
                        "Pick",
                        "5bf115d",
                        "This is a commit"});
            table1.AddRow(new string[] {
                        "Squash",
                        "2525a53",
                        "Another commit"});
            table1.AddRow(new string[] {
                        "Squash",
                        "f799a4f",
                        "A third commit"});
#line 8
 testRunner.Given("the rebase has the following:", ((string)(null)), table1, "Given ");
#line 13
 testRunner.And("the rebase file exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
   testRunner.When("I read the rebase file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action",
                        "CommitHash",
                        "Subject"});
            table2.AddRow(new string[] {
                        "Pick",
                        "5bf115d",
                        "This is a commit"});
            table2.AddRow(new string[] {
                        "Squash",
                        "2525a53",
                        "Another commit"});
            table2.AddRow(new string[] {
                        "Squash",
                        "f799a4f",
                        "A third commit"});
#line 15
   testRunner.Then("the rebase document should contain:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RebaseFileReaderFeatureFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RebaseFileReaderFeatureFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
