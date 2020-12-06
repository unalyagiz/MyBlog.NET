# MyBlog.NET

This project has been developed in 3 days for an interview task. It's been approved as successful by the supervisor who gave the constraints about the project.

#### Constraints were the followings

- Create a blog website to share posts (specifically controlled by one person).
- Different login mechanism to differentiate user and admin.
- People can sign-in to make a comment otherwise just seeing posts.


<br/>

#### So, for the first task, i created an admin login page to give admin to capability of adding posts. I did not display the login link on a UI unit. So everybody can not messed with it. Even if they can access to admin login page, they are not authorized to making operations.



<img src="https://github.com/unalyagiz/MyBlog.NET/blob/master/gifs/admin_add_post.gif"/>

<br/>
<hr/>
#### For the second and third task, when users login their cookies stored and checked if they are logged in or not. If they are not then show the "please login to make a comment" button else show them a textbox to type their comment. When the comment has been sent there is a AJAX form to keep the comment to show on that page without reloading it and saved to database to being seen from everyone. That feature improves usability and make website more user friendly.


<img src="https://github.com/unalyagiz/MyBlog.NET/blob/master/gifs/make_comment.gif"/>

<br/>
<hr/>
#### Also for improving usability much more, i implemented a search box to searching keyword through posts. I achieved that with an AJAX call to check the keyword in descriptions of all the posts and return the matching ones. I have created it in Layout page to make it accessible globally.

<img src="https://github.com/unalyagiz/MyBlog.NET/blob/master/gifs/search_posts.gif"/>
