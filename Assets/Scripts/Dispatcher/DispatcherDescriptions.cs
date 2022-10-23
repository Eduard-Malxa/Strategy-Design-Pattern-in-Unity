using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DispatcherDescriptions : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI descriptionText;

    [SerializeField]
    private Image backgroundImage;

    private Transport currentTransport;

    private CancellationTokenSource canellationTokenSource;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void TransportSendedText(Transport transport)
    {
        gameObject.SetActive(true);

        TryCancelToken();

        currentTransport = transport;
        backgroundImage.color = Color.white;
        descriptionText.text = $"{currentTransport.name} sended";
    }

    public async void TransportArrivedText()
    {
        backgroundImage.color = Color.green;
        descriptionText.text = $"{currentTransport.name} arrived";
        await TaskDelay(2000);
    }

    private async Task TaskDelay(int interval)
    {
        try
        {
            canellationTokenSource = new CancellationTokenSource();
            var tokenSource = canellationTokenSource.Token;

            await Task.Delay(interval, tokenSource);

            if (canellationTokenSource.IsCancellationRequested == false && this != null)
            {
                gameObject.SetActive(false);
            }
        }
        catch (OperationCanceledException e)
        {
            //Debug.Log(e);
        }
    }

    private void TryCancelToken()
    {
        if (canellationTokenSource != null)
        {
            canellationTokenSource.Cancel();
        }
    }
}
