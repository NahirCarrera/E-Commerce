﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TDDECommmerce.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RegistroDeUsuariosFeature : object, Xunit.IClassFixture<RegistroDeUsuariosFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Registro de Usuarios", "  Como usuario nuevo\r\n  Quiero poder registrarme en el sistema\r\n  Para poder acce" +
                "der a los servicios ofrecidos", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "RegistroUsuarios.feature"
#line hidden
        
        public RegistroDeUsuariosFeature(RegistroDeUsuariosFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Registro de usuarios válidos")]
        [Xunit.TraitAttribute("FeatureTitle", "Registro de Usuarios")]
        [Xunit.TraitAttribute("Description", "Registro de usuarios válidos")]
        [Xunit.TraitAttribute("Category", "CP-01")]
        [Xunit.TraitAttribute("Category", "Alta")]
        public async System.Threading.Tasks.Task RegistroDeUsuariosValidos()
        {
            string[] tagsOfScenario = new string[] {
                    "CP-01",
                    "Alta"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Registro de usuarios válidos", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 9
    await testRunner.GivenAsync("que el formulario de registro está disponible", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 10
    await testRunner.WhenAsync("ingreso mi nombre \"Usuario1\", apellido \"Prueba\", correo \"user1@example.com\", cont" +
                        "raseña \"UserTest1234*\" y confirmo la contraseña \"UserTest1234*\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 11
    await testRunner.AndAsync("envío el formulario", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 12
    await testRunner.ThenAsync("el sistema debe aceptar el registro", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Registro de usuarios inválidos - contraseña inválida")]
        [Xunit.TraitAttribute("FeatureTitle", "Registro de Usuarios")]
        [Xunit.TraitAttribute("Description", "Registro de usuarios inválidos - contraseña inválida")]
        [Xunit.TraitAttribute("Category", "CP-02")]
        [Xunit.TraitAttribute("Category", "Alta")]
        public async System.Threading.Tasks.Task RegistroDeUsuariosInvalidos_ContrasenaInvalida()
        {
            string[] tagsOfScenario = new string[] {
                    "CP-02",
                    "Alta"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Registro de usuarios inválidos - contraseña inválida", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 15
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 16
    await testRunner.GivenAsync("que el formulario de registro está disponible", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 17
    await testRunner.WhenAsync("ingreso mi nombre \"Usuario2\", apellido \"Prueba\", correo \"user2@example.com\", cont" +
                        "raseña \"User2\" y confirmo la contraseña \"User2\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 18
    await testRunner.AndAsync("envío el formulario", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 19
    await testRunner.ThenAsync("el sistema no debe aceptar el registro", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 20
    await testRunner.AndAsync("se debe mostrar un mensaje de advertencia indicando el formato esperado de contra" +
                        "seña:", "Passwords must be at least 6 characters.\r\nPasswords must have at least one non al" +
                        "phanumeric character.", ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Registro de usuarios inválidos - contraseña no coincide con la confirmación")]
        [Xunit.TraitAttribute("FeatureTitle", "Registro de Usuarios")]
        [Xunit.TraitAttribute("Description", "Registro de usuarios inválidos - contraseña no coincide con la confirmación")]
        [Xunit.TraitAttribute("Category", "CP-03")]
        [Xunit.TraitAttribute("Category", "Alta")]
        public async System.Threading.Tasks.Task RegistroDeUsuariosInvalidos_ContrasenaNoCoincideConLaConfirmacion()
        {
            string[] tagsOfScenario = new string[] {
                    "CP-03",
                    "Alta"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Registro de usuarios inválidos - contraseña no coincide con la confirmación", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 28
    await testRunner.GivenAsync("que el formulario de registro está disponible", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 29
    await testRunner.WhenAsync("ingreso mi nombre \"Usuario3\", apellido \"Prueba\", correo \"user3@example.com\", cont" +
                        "raseña \"User2\" y confirmo la contraseña \"User\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 30
    await testRunner.AndAsync("envío el formulario", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 31
    await testRunner.ThenAsync("el sistema no debe aceptar el registro", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 32
    await testRunner.AndAsync("se debe mostrar un mensaje de advertencia indicando que las contraseñas no coinci" +
                        "den:", "\'ConfirmPassword\' and \'Password\' do not match.", ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Registro de usuarios inválidos - Campos vacíos")]
        [Xunit.TraitAttribute("FeatureTitle", "Registro de Usuarios")]
        [Xunit.TraitAttribute("Description", "Registro de usuarios inválidos - Campos vacíos")]
        [Xunit.TraitAttribute("Category", "CP-04")]
        [Xunit.TraitAttribute("Category", "Alta")]
        public async System.Threading.Tasks.Task RegistroDeUsuariosInvalidos_CamposVacios()
        {
            string[] tagsOfScenario = new string[] {
                    "CP-04",
                    "Alta"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Registro de usuarios inválidos - Campos vacíos", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 39
    await testRunner.GivenAsync("que el formulario de registro está disponible", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 40
    await testRunner.WhenAsync("envío el formulario sin llenar los datos", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 41
    await testRunner.ThenAsync("el sistema no debe aceptar el registro", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 42
    await testRunner.AndAsync("se debe mostrar un mensaje de advertencia indicando que los campos son obligatori" +
                        "os:", "The First Name field is required.\r\nThe Last Name field is required.\r\nThe Email fi" +
                        "eld is required.\r\nThe Password field is required.\r\nThe ConfirmPassword field is " +
                        "required.", ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await RegistroDeUsuariosFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await RegistroDeUsuariosFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
