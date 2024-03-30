using FluentSysInfo.Core.Enums;

namespace FluentSysInfo.Core.Models
{
    public class SysInfoModel
    {

        public FluentSysInfoTypes SysInfoType { get; set; }
        public string RelatedWMIClassName { get; set; }



        public SysInfoModel(FluentSysInfoTypes sysInfoType,
                            string relatedWMIClassName)
        {
            if (string.IsNullOrWhiteSpace(relatedWMIClassName))
            {
                throw new System.ArgumentException($"'{nameof(relatedWMIClassName)}' cannot be null or whitespace.", nameof(relatedWMIClassName));
            }

            if (sysInfoType == 0 || sysInfoType == FluentSysInfoTypes.DateTime)
            {
                throw new System.ArgumentException($"'{nameof(sysInfoType)}' is not supported.", nameof(sysInfoType));
            }

            SysInfoType = sysInfoType;
            RelatedWMIClassName = relatedWMIClassName;
        }



    }
}
