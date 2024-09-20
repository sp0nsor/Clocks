using System;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;

public class TimeService : ITimeService
{
    private readonly string timeUrl = "https://yandex.com/time/sync.json";

    public async Task<DateTime> GetNetworkTime()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(timeUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string json = await responseMessage.Content.ReadAsStringAsync();
                    long unixTimeMillis = JsonUtility.FromJson<TimeData>(json).time;
                    DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMillis).DateTime;

                    Debug.Log(dateTime.ToString());
                    return dateTime;
                }
                else
                {
                    Debug.LogError("Failed to get time from server");
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        return DateTime.Now;
    }

    [Serializable]
    private class TimeData
    {
        public long time;
    }
}
