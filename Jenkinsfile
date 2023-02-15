pipeline {
    agent any
    
    triggers {
        githubPush()
    }

    stages {
        stage('Build') {
            steps {
                sh 'echo "building"'
            }
        }
    }

    post {
        success {
            sh 'echo "success"'
        }
        failure {
            sh 'echo "Build failed"'
        }
    }
}
