﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18213
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
    [NUnit.Framework.DescriptionAttribute("Castling")]
    public partial class CastlingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Castling.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Castling", @"Castling is a special move in 
the game of chess involving the 
king and either of the original 
rooks of the same color.

Castling is permissible if and only if all of the following conditions hold:

The king has not previously moved.
The chosen rook has not previously moved.
There are no pieces between the king and the chosen rook.
The king is not currently in check.
The king does not pass through a square that is under attack by enemy pieces.
The king does not end up in check (true of any legal move).
The king and the chosen rook are on the same rank.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("White\'s kingside casteling")]
        public virtual void WhiteSKingsideCasteling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("White\'s kingside casteling", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("a new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And("the game has just started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.When("White move g1 to h3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And("Black move e7 to e6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("White move e2 to e3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("Black move e6 to e5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("White move f1 to e2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Black move e5 to e4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("White move e1 to g1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.Then("there should be a white king at g1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("there should be a white rook at f1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("e1 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("h1 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("it should be Black\'s turn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("White\'s queenside casteling")]
        public virtual void WhiteSQueensideCasteling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("White\'s queenside casteling", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("a new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("the game has just started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("White move b1 to a3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.And("Black move e7 to e6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("White move e2 to e3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("Black move e6 to e5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("White move d2 to d3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("Black move e5 to e4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("White move c1 to d2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("Black move d7 to d6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("White move d1 to e2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("Black move d6 to d5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("White move e1 to c1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.Then("there should be a white king at c1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.And("there should be a white rook at d1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("e1 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("a1 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("it should be Black\'s turn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Black\'s kingside casteling")]
        public virtual void BlackSKingsideCasteling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Black\'s kingside casteling", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
testRunner.Given("a new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.And("the game has just started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.When("White move a2 to a3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.And("Black move g8 to h6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("White move a3 to a4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("Black move e7 to e6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("White move a4 to a5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("Black move f8 to e7", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("White move a5 to a6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("Black move e8 to g8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.Then("there should be a black king at g8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
 testRunner.And("there should be a black rook at f8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("e8 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("h8 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("it should be White\'s turn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Black\'s queenside casteling")]
        public virtual void BlackSQueensideCasteling()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Black\'s queenside casteling", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
testRunner.Given("a new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("the game has just started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("White move h2 to h3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And("Black move b8 to a6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("White move h3 to h4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("Black move e7 to e6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("White move h4 to h5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("Black move d8 to e7", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("White move h5 to h6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("Black move d7 to d6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("White move b2 to b3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And("Black move c8 to d7", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("White move b3 to b4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("Black move e8 to c8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.Then("there should be a black king at c8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.And("there should be a black rook at d8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("e8 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("a8 should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("it should be White\'s turn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if king has moved")]
        public virtual void CannotCastleIfKingHasMoved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if king has moved", ((string[])(null)));
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given("a new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.And("the game has just started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.When("White move g1 to h3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.And("Black move e7 to e6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("White move e2 to e3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("Black move e6 to e5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("White move f1 to e2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("Black move e5 to e4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("White move e1 to f1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("Black move a7 to a6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("White move f1 to e1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("Black move a6 to a5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.Then("White should not be able to move e1 to g1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if chosen rook has moved")]
        public virtual void CannotCastleIfChosenRookHasMoved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if chosen rook has moved", ((string[])(null)));
#line 108
this.ScenarioSetup(scenarioInfo);
#line 109
 testRunner.Given("TODO", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if there are pieces in between")]
        public virtual void CannotCastleIfThereArePiecesInBetween()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if there are pieces in between", ((string[])(null)));
#line 110
this.ScenarioSetup(scenarioInfo);
#line 111
 testRunner.Given("TODO", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if king is in check")]
        public virtual void CannotCastleIfKingIsInCheck()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if king is in check", ((string[])(null)));
#line 112
this.ScenarioSetup(scenarioInfo);
#line 113
 testRunner.Given("TODO", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if king would pass through a square that is under attack")]
        public virtual void CannotCastleIfKingWouldPassThroughASquareThatIsUnderAttack()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if king would pass through a square that is under attack", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 115
 testRunner.Given("TODO", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if king would would end up in check")]
        public virtual void CannotCastleIfKingWouldWouldEndUpInCheck()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if king would would end up in check", ((string[])(null)));
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
 testRunner.Given("TODO", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cannot castle if king and chosen rook is not on the same rank (same as second?)")]
        public virtual void CannotCastleIfKingAndChosenRookIsNotOnTheSameRankSameAsSecond()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot castle if king and chosen rook is not on the same rank (same as second?)", ((string[])(null)));
#line 118
this.ScenarioSetup(scenarioInfo);
#line 119
 testRunner.Given("TODO", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
