﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ebank.AccountContext.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ebank.AccountContext.Resource.ExceptionResource", typeof(ExceptionResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Account number could not be zero or smaller than zero..
        /// </summary>
        public static string AccountNumberCouldNotBeSmallerThanZero {
            get {
                return ResourceManager.GetString("AccountNumberCouldNotBeSmallerThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Account number exist. please insert another account number..
        /// </summary>
        public static string AccountNumberDuplication {
            get {
                return ResourceManager.GetString("AccountNumberDuplication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Account number not exists. {0}.
        /// </summary>
        public static string AccountNumberNotExist {
            get {
                return ResourceManager.GetString("AccountNumberNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only individual accounts can deposit..
        /// </summary>
        public static string DepositToCorporateAccount {
            get {
                return ResourceManager.GetString("DepositToCorporateAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No enough cash..
        /// </summary>
        public static string NoEnoughBalanceForPayment {
            get {
                return ResourceManager.GetString("NoEnoughBalanceForPayment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Payment just can done to a corporate account..
        /// </summary>
        public static string PaymentToIndividualAccount {
            get {
                return ResourceManager.GetString("PaymentToIndividualAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only individual account can do payments..
        /// </summary>
        public static string PaymentWithCorporateAccount {
            get {
                return ResourceManager.GetString("PaymentWithCorporateAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to you can withdraw just from individual account..
        /// </summary>
        public static string WithdrawFromCorporateAccount {
            get {
                return ResourceManager.GetString("WithdrawFromCorporateAccount", resourceCulture);
            }
        }
    }
}