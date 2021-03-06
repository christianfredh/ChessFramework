﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18010
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ChessFramework.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Game Start")]
    public partial class GameStartFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GameStart.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Game Start", "When the game start\r\nI want the game set up correctly", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Starting a game")]
        public virtual void StartingAGame()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Starting a game", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("a new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.When("the game starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "BRo",
                        "BKn",
                        "BBi",
                        "BQu",
                        "BKi",
                        "BBi",
                        "BKn",
                        "BRo"});
            table1.AddRow(new string[] {
                        "BPa",
                        "BPa",
                        "BPa",
                        "BPa",
                        "BPa",
                        "BPa",
                        "BPa",
                        "BPa"});
            table1.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "WPa",
                        "WPa",
                        "WPa",
                        "WPa",
                        "WPa",
                        "WPa",
                        "WPa",
                        "WPa"});
            table1.AddRow(new string[] {
                        "WRo",
                        "WKn",
                        "WBi",
                        "WQu",
                        "WKi",
                        "WBi",
                        "WKn",
                        "WRo"});
#line 8
 testRunner.Then("the board should look like", ((string)(null)), table1, "Then ");
#line 18
 testRunner.And("it should be White\'s turn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
