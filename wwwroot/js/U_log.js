// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const userBehaviorLog = [];

let pageLoadTime = 0;
let pageUnloadTime = 0;

window.addEventListener('load', () => {
  pageLoadTime = window.performance.timing.loadEventEnd - window.performance.timing.navigationStart;
});

window.addEventListener('beforeunload', () => {
  pageUnloadTime = Date.now();
});

function logUserBehavior(action, data) {
  const timeSpentOnPage = pageUnloadTime - pageLoadTime;

  userBehaviorLog.push({
    timestamp: new Date(),
    action,
    data,
    timeSpentOnPage
  });

  // Log the data to the console
  console.log('User behavior:', userBehaviorLog);
}
