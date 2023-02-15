pipeline {
    agent any
    
    triggers {
        githubPush()
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                bat 'echo "building"'
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
