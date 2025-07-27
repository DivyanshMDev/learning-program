import React from 'react';
import Post from './Post'; 
class Posts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [
         new Post(1, 'Learning Project by Divyansh Modi', 'This is my learning journey with React and JavaScript. Building amazing projects step by step.'),
        new Post(2, 'React Components Mastery', 'Understanding class components, state management, and lifecycle methods in this project by Divyansh Modi.')
      ]
    };
  }

  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then(response => response.json())
      .then(data => {
        
        const postInstances = data.map(postData => 
          new Post(postData.id, postData.title, postData.body)
        );
        this.setState({ posts: postInstances });
      })
      .catch(error => {
        console.error('Error fetching posts:', error);
      });
  }

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, errorInfo) {
    alert(`Error occurred in Posts component: ${error.message}`);
    console.error('Error details:', error, errorInfo);
  }

  render() {
    const { posts } = this.state;
    
    return (
      <div>
        <h2>Posts</h2>
        {posts.length === 0 ? (
          <p>Loading posts...</p>
        ) : (
          posts.map(post => (
            <div key={post.id} style={{ marginBottom: '20px', border: '1px solid #ccc', padding: '10px' }}>
              <h3>{post.title}</h3>
              <p>{post.body}</p>
            </div>
          ))
        )}
      </div>
    );
  }
}

export default Posts;
