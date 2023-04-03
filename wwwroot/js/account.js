const logoutBtn = document.getElementById('logout-btn');
logoutBtn.addEventListener('click', function() {
    document.cookie = 'authToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
    window.location.href = '/Re-LO';
});
const cookies = document.cookie.split(';');
let username = null;
let userId = null;
for (let i = 0; i < cookies.length; i++) {
const cookie = cookies[i].trim();
if (cookie.startsWith('username=')) {
username = cookie.substring('username='.length, cookie.length);
}
if (cookie.startsWith('userId=')) {
userId = cookie.substring('userId='.length, cookie.length);
}
}

if (username) {
document.getElementById('user-name').textContent = username;
} else {
document.getElementById('user-name').textContent = '[unknown]';
}


const payButtons = document.querySelectorAll('.pay-button');
payButtons.forEach(button => {
button.addEventListener('click', async () => {
try {
const response = await fetch('http://192.168.0.144:443/api/Users/UpdateSubscription?id=62&subscription=1', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json'
  },
});

const result = await response.json();
console.log(result);
// Display success message to user
} catch (error) {
console.error(error);
// Display error message to user
}
});
});