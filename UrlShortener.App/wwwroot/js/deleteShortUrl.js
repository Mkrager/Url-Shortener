async function deleteShortUrl(shortUrlId) {
    try {
        const response = await fetch(`/shortUrl/delete/${shortUrlId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.ok) {
            const data = await response.json();
            if (data.redirectUrl) {
                window.location.href = data.redirectUrl;
            } else {
                const row = document.querySelector(`tr[data-id="${shortUrlId}"]`);
                if (row) row.remove();
            }
        } else {
            const error = await postResponse.json();
            alert(error.error);
        }
    } catch (err) {
        console.error('Error:', err);
        alert('Error occurred while deleting URL.');
    }
}
