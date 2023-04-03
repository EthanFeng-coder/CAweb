const switchToLoginFormButton = document.getElementById('switch-to-login');
const switchToRegistrationFormButton = document.getElementById('switch-to-registration');
const registrationForm = document.getElementById('register-form');
const loginForm = document.getElementById('login-form');

// Show the login form and hide the registration form
switchToLoginFormButton.addEventListener('click', function(event) {
  event.preventDefault();
  registrationForm.style.display = 'none';
  loginForm.style.display = 'block';
});

// Show the registration form and hide the login form
switchToRegistrationFormButton.addEventListener('click', function(event) {
  event.preventDefault();
  loginForm.style.display = 'none';
  registrationForm.style.display = 'block';
});


registrationForm.addEventListener('submit', function(event) {
  event.preventDefault();

  // Get the form values
  const username = document.getElementById('username').value;
  const email = document.getElementById('email').value;
  const password = document.getElementById('password').value;
  const confirmPassword = document.getElementById('confirm-password').value;

  // Create a new user object with the form values
  const newUser = {
    id: 0,
    userName: username,
    email: email,
    password: password
  };

  // Send the user object to the API endpoint
  fetch('http://192.168.0.144:443/api/Register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(newUser)
  })
  .then(response => {
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return response.json();
  })
  .then(data => {
    // Handle the response data
    console.log(data);
   
    loginForm.style.display = 'block';
    registrationForm.style.display = 'none';
  })
  .catch(error => {
    // Handle any errors
    console.error('There was an error sending the request', error);
  });
});

loginForm.addEventListener('submit', async (event) => {
  event.preventDefault();

  const loginEmail = document.getElementById('login-email').value;
  const loginPassword = document.getElementById('login-password').value;

  const data = {
    id: 0,
    userName: loginEmail,
    email: loginEmail,
    password: loginPassword
  };

try {
  const response = await fetch('http://192.168.0.144:443/api/Users/Login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });

  const result = await response.json();

  if (response.status === 200) {
    const expirationDate = new Date();
    expirationDate.setTime(expirationDate.getTime() + (60 * 60 * 1000));
    document.cookie = `authToken=${result.authToken}; path=/; expires=${expirationDate.toUTCString()}`;
    document.cookie = `username=${result.userName}; path=/; expires=${expirationDate.toUTCString()}`;
    document.cookie = `userId=${result.id}; path=/; expires=${expirationDate.toUTCString()}`;

    window.location.href = `/Account?auth=true`;
  } else {
    console.log(result.message);
  }
} catch (error) {
  console.error(error);
  alert(error);
}
});

