#define OFFLINE_SYNC_ENABLE


using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Helpers
{
    public class AzureAppServiceHelper
    {
        public static async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await App.MobileService.SyncContext.PushAsync();

                await App.postTable.PullAsync("userPost","");

            }
            catch (MobileServicePushFailedException pf)
            {
                if (pf.PushResult != null)
                    syncErrors = pf.PushResult.Errors;
            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error while syncronizing post table " + ex);
            }

            if(syncErrors != null)
            {
                foreach(var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                        await error.CancelAndUpdateItemAsync(error.Result);
                    else
                        await error.CancelAndDiscardItemAsync();
                }
            }
        }
    }
}
