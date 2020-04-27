using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Server.Components
{
    public class BenefitSelectorBase : ComponentBase
    {
        [Inject]
        public IBenefitDataService BenefitDataService { get; set; }

        [Parameter]
        public EmployeeModel Employee { get; set; }

        protected IEnumerable<BenefitModel> Benefits { get; set; }

        protected bool SaveButtonDisabled { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            Benefits = await BenefitDataService.GetForEmployee(Employee);
        }

        public void CheckBoxChanged(ChangeEventArgs e, BenefitModel benefit)
        {
            var newValue = (bool)e.Value;
            benefit.Selected = newValue;
            SaveButtonDisabled = false;

            if (newValue)
            {
                benefit.StartDate = DateTime.Now;
                benefit.EndDate = DateTime.Now.AddYears(1);
            }
        }

        public void SaveClick()
        {
            BenefitDataService.UpdateForEmployee(Employee, Benefits);
            SaveButtonDisabled = true;
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override bool ShouldRender()
        {
            return base.ShouldRender();
        }
    }
}
