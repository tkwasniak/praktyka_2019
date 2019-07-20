using MovieRental.Core.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace MovieRental.Web.Common
{
    public class CategoryRatingRequired : ValidationAttribute, IClientValidatable
    {
        public string propName;
        public CategoryRatingRequired(string _propName)
        {
            propName = _propName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool flag = false;
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(propName);
            object propertyValue = property.GetValue(instance);

            if (propertyValue == null)
            {
                flag = false;
            }
            else
            {
                switch (value.ToString())
                {
                    case "Horror":
                        {
                            if ((FilmRating)propertyValue == FilmRating.R || (FilmRating)propertyValue == FilmRating.NC17)
                            {
                                flag = true;
                            }
                            break;
                        }

                    default:
                        flag = true;
                        break;
                }
            }
            if (!flag)
            {
                ValidationResult result = new ValidationResult
                    (this.ErrorMessage);
                return result;
            }
            else
            {
                return null;
            }
        }



        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {

            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessage,
                ValidationType = "categoryratingcheck",
            };
            rule.ValidationParameters.Add("selection", this.propName);
            yield return rule;
        }
    }
}