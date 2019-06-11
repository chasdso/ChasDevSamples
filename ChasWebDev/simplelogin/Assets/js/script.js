var profile = [
    {
        username: "chas",
        pword: "777"
    },
    {
        username: "ingrid",
        pword: "777"
    },
    {
        username: "janet",
        pword: "777"
    }
];

var newsFeed = [
    {
        username: "chas",
        timeline: "Loving front-end dev"
    },
    {
        username: "janet",
        timeline: "I think my toast is burning"
    },
    {
        username: "ingrid",
        timeline: "Green lantern of course is the best comic book hero"
    }
];

function isLoginValid(user, pass) {
    for (var i = 0; i < profile.length; i++) {
        if (profile[i].username === user && profile[i].pword === pass) {
            return true;
        }
    }
    return false;

}

function signIn(user, pass) {
    if (isLoginValid(user, pass)) {
        console.log(newsFeed);

    } else {
        alert("Sorry, wrong username and password");

    }
}
// if (user === profile[0].username && pass === profile[0].pword) {
//     console.log(newsFeed);
// }
// else {
//     alert("Sorry, username does not exist or username and password do not match");
// }


var promptUserName = prompt("Please enter username");
var promptPassWord = prompt("Please enter password");

signIn(promptUserName, promptPassWord);