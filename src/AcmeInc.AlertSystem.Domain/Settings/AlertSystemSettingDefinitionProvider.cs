﻿using Volo.Abp.Settings;

namespace AcmeInc.AlertSystem.Settings;

public class AlertSystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AlertSystemSettings.MySetting1));
    }
}